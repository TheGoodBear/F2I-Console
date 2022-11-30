using Microsoft.IdentityModel.Tokens;

namespace DatabaseRecursive.Models;

internal class Category
{

    #region "Properties"
    // static
    public static List<Category> Elements = new List<Category>();

    // model
    public int ID { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int? IDParentCategory { get; set; }

    // calculated
    public List<int> ParentIDs { get; set; } = new List<int>();
    public string FullHierarchy { get; set; }
    #endregion


    #region "Constructors"
    public Category(
        int ID,
        string Name,
        string Description,
        int? IDParentCategory = null)
    {
        this.ID = ID;
        this.Name = Name;
        this.Description = Description;
        this.IDParentCategory = IDParentCategory;

        GetHierarchy(this.IDParentCategory);
        if (!FullHierarchy.IsNullOrEmpty())
            FullHierarchy = $"({FullHierarchy.Trim()})";
    }
    public Category(
        string Name,
        string Description,
        int? IDParentCategory = null)
    {
        this.Name = Name;
        this.Description = Description;
        this.IDParentCategory = IDParentCategory;
    }
    #endregion


    #region "Methods"
    public override string ToString()
    {
        return
            $"{Name}" +
            $"{(Description.IsNullOrEmpty() ? "" : $" ({Description})")}";
    }

    public string DisplayWithHierarchy(
        bool ShowFullHierarchy = false)
    {
        string Result = $"({ID}) {Name}";

        if (ShowFullHierarchy)
            Result += $"{(this.FullHierarchy.IsNullOrEmpty() ? "" : $" {this.FullHierarchy}")}";
        else
            Result += $"{(IDParentCategory == null ? "" : $" (↑ {IDParentCategory})")}";

        return Result;
    }

    // recursive method to get hierarchy
    private void GetHierarchy(
        int? IDParent = null)
    {

        //Console.WriteLine("\n" + Element);
        //Console.WriteLine(string.Join(", ", Element.ParentIDs));

        // element has a parent
        if (IDParent != null)
        {
            // get parent
            Category ParentElement = Elements
                .First(e => e.ID == IDParent);

            // update element properties
            ParentIDs.Add(ParentElement.ID);
            FullHierarchy += $" ◄ {ParentElement.Name}";

            // recursively call method for higher parents
            GetHierarchy(ParentElement.IDParentCategory);
        }

    }


    #endregion


}
