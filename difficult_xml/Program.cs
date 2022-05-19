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

        /// <summary>
        /// Class to hold a skill
        /// </summary>
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
                        case nameof(staminaLevel): staminaLevel = (int)property; break;
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
            public override string ToString()
            {
                List<string> builder = new List<string>();
                builder.Add($"\t{SkillsType}");
                builder.Add($"\t\t{nameof(skillKey)}:{skillKey}");
                builder.Add($"\t\t{nameof(skillLevel)}:{skillLevel}");
                builder.Add($"\t\t{nameof(accuracyLevel)}:{accuracyLevel}");
                builder.Add($"\t\t{nameof(damageLevel)}:{damageLevel}");
                builder.Add($"\t\t{nameof(staminaLevel)}:{staminaLevel}");
                builder.Add($"\t\t{nameof(chanceLevel)}:{chanceLevel}");
                return string.Join(Environment.NewLine, builder);
            }
        }

        /// <summary>
        /// Parser routine
        /// </summary>
        static void Main(string[] args)
        {
            Dictionary<string, List<Skill>> skillsByUser = new Dictionary<string, List<Skill>>();

            // Read in the source
            var xdoc = XDocument.Parse(source);
            // Get the Profession element...
            var profession = xdoc.Element("Profession");
            // ... and go through the skills it contains
            foreach (SkillsType skillsType in Enum.GetValues(typeof(SkillsType)))
            {
                var group = profession.Element(skillsType.ToString()); // Top element
                group = (XElement)group.Elements().First(); // Burn this unused element.

                // Here's where I assume these are users i0, i1 etc. but you tell me.
                foreach (var user in group.Elements())
                {
                    if(!skillsByUser.ContainsKey(user.Name.LocalName))
                    {
                        skillsByUser[user.Name.LocalName] = new List<Skill>();
                    }
                    skillsByUser[user.Name.LocalName].Add(new Skill(skillsType, user));
                }
            }

            // Print out the dictionary that this made.
            foreach (var key in skillsByUser.Keys)
            {
                var list = skillsByUser[key];
                Console.WriteLine($"User: {key}");
                foreach (var skill in list)
                {
                    Console.WriteLine(skill.ToString());
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
