using System.Collections.Generic;
public class CO
{
    // Universal attack and defense attributes
    public int UniversalATK { get; set; }
    public int UniversalDEF { get; set; }

    // Dictionary to store individual attack and defense attributes for each unit
    public Dictionary<Unit, int> IndividualATK { get; private set; }
    public Dictionary<Unit, int> IndividualDEF { get; private set; }
}