using Library_MVP.Logic.Service;
using Library_MVP.Models;
using Library_MVP.Views.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_MVP.Logic.Presenter
{
    class CategoryPresenter
    {

        ICategory iCategory;
        CategoryModel CatModel=new CategoryModel();

        public CategoryPresenter(ICategory View)
        {
            this.iCategory = View;
        }
        // Connect Between ModelCat and IntefaceCat
        private void ConnectBetweenModelAndInterface()
        {
            CatModel.ID = iCategory.ID;
            CatModel.CatName = iCategory.CatName;
        }

        public bool CatInsert()
        {
            ConnectBetweenModelAndInterface();
            return CategoryService.CategoryInsert(CatModel.ID, CatModel.CatName);
        }
    }
}
