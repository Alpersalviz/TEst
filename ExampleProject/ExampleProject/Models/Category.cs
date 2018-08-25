using System;
namespace ExampleProject.Models
{
    public class Category
    {

        public string Title { get; set; }
        public Category ParentCategory { get; set; }


        public Category(string title)
        {
            this.Title = title;

        }

        public Category(string title, Category parentCategory)
        {
            this.Title = title;
            this.ParentCategory = parentCategory;

        }


    }
}
