using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace difficult_xml
{
    class Program
    {
        enum SkillsType
        {
            StrengthSkills,
            DexteritySkills,
            IntelligenceSkills,
            CharismaSkills,
            PerceptionSkills, 
            FortitudeSkills,
        }
        class Skill
        {
            public Skill(SkillsType type, XElement xel)
            {
                SkillsType = type;
                foreach (var property in xel.Elements())
                {
                    switch (property.Name.LocalName)
                    {
                        case nameof(skillKey): skillKey = (int)property; break;
                        case nameof(skillLevel): skillLevel = (int)property; break;
                        case nameof(accuracyLevel): accuracyLevel = (int)property; break;
                        case nameof(damageLevel): damageLevel = (int)property; break;
                        case nameof(staminaLevel): skillKey = (int)property; break;
                        case nameof(chanceLevel): chanceLevel = (int)property; break;
                    } 
                }
            }
            public SkillsType SkillsType{get;set;}
            public int skillKey { get; set; }
            public int skillLevel { get; set; }
            public int accuracyLevel { get; set; }
            public int damageLevel { get; set; }
            public int staminaLevel { get; set; }
            public int chanceLevel { get; set; }
        }
        static void Main(string[] args)
        {
            Dictionary<string, List<Skill>> skillsByUser = new Dictionary<string, List<Skill>>();

            var xdoc = XDocument.Parse(source);
            var profession = xdoc.Element("Profession");
            foreach (SkillsType skillsType in Enum.GetValues(typeof(SkillsType)))
            {
                var group = profession.Element(skillsType.ToString());
                group = (XElement)group.Elements().First(); // Burn this unused element.
                foreach (var user in group.Elements())
                {
                    if(!skillsByUser.ContainsKey(user.Name.LocalName))
                    {
                        skillsByUser[user.Name.LocalName] = new List<Skill>();
                    }
                    skillsByUser[user.Name.LocalName].Add(new Skill(skillsType, user));
                }
            }
        }

        const string source = @"<Profession>
  <StrengthSkills>
    <strengthSkills size=""3"">
      <i0>
        <skillKey>25</skillKey>
        <skillLevel>1</skillLevel>
        <accuracyLevel>0</accuracyLevel>
        <damageLevel>0</damageLevel>
        <staminaLevel>0</staminaLevel>
        <chanceLevel>0</chanceLevel>
      </i0>
      <i1>
        <skillKey>41</skillKey>
        <skillLevel>1</skillLevel>
        <accuracyLevel>0</accuracyLevel>
        <damageLevel>0</damageLevel>
        <staminaLevel>0</staminaLevel>
        <chanceLevel>0</chanceLevel>
      </i1>
      <i2>
        <skillKey>12</skillKey>
        <skillLevel>1</skillLevel>
        <accuracyLevel>0</accuracyLevel>
        <damageLevel>0</damageLevel>
        <staminaLevel>0</staminaLevel>
        <chanceLevel>0</chanceLevel>
      </i2>
    </strengthSkills>
  </StrengthSkills>
  <DexteritySkills>
    <dexteritySkills size=""2"">
      <i0>
        <skillKey>105</skillKey>
        <skillLevel>1</skillLevel>
        <accuracyLevel>0</accuracyLevel>
        <damageLevel>0</damageLevel>
        <staminaLevel>0</staminaLevel>
        <chanceLevel>0</chanceLevel>
      </i0>
      <i1>
        <skillKey>131</skillKey>
        <skillLevel>1</skillLevel>
        <accuracyLevel>0</accuracyLevel>
        <damageLevel>0</damageLevel>
        <staminaLevel>0</staminaLevel>
        <chanceLevel>0</chanceLevel>
      </i1>
    </dexteritySkills>
  </DexteritySkills>
  <IntelligenceSkills>
    <intelligenceSkills size=""1"">
      <i0>
        <skillKey>208</skillKey>
        <skillLevel>1</skillLevel>
        <accuracyLevel>0</accuracyLevel>
        <damageLevel>0</damageLevel>
        <staminaLevel>0</staminaLevel>
        <chanceLevel>0</chanceLevel>
      </i0>
    </intelligenceSkills>
  </IntelligenceSkills>
  <CharismaSkills>
    <charismaSkills size=""2"">
      <i0>
        <skillKey>304</skillKey>
        <skillLevel>2</skillLevel>
        <accuracyLevel>0</accuracyLevel>
        <damageLevel>0</damageLevel>
        <staminaLevel>0</staminaLevel>
        <chanceLevel>0</chanceLevel>
      </i0>
      <i1>
        <skillKey>309</skillKey>
        <skillLevel>1</skillLevel>
        <accuracyLevel>0</accuracyLevel>
        <damageLevel>0</damageLevel>
        <staminaLevel>0</staminaLevel>
        <chanceLevel>0</chanceLevel>
      </i1>
    </charismaSkills>
  </CharismaSkills>
  <PerceptionSkills>
    <perceptionSkills size=""1"">
      <i0>
        <skillKey>405</skillKey>
        <skillLevel>1</skillLevel>
        <accuracyLevel>0</accuracyLevel>
        <damageLevel>0</damageLevel>
        <staminaLevel>0</staminaLevel>
        <chanceLevel>0</chanceLevel>
      </i0>
    </perceptionSkills>
  </PerceptionSkills>
  <FortitudeSkills>
    <fortitudeSkills size=""1"">
      <i0>
        <skillKey>500</skillKey>
        <skillLevel>2</skillLevel>
        <accuracyLevel>0</accuracyLevel>
        <damageLevel>0</damageLevel>
        <staminaLevel>0</staminaLevel>
        <chanceLevel>0</chanceLevel>
      </i0>
    </fortitudeSkills>
  </FortitudeSkills>
</Profession>";
    }
}
