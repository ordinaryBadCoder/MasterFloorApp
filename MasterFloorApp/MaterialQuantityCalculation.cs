using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MasterFloorApp
{    /// <summary>
     /// Класс MaterialQuantityCalculation предоставляет функцию для одинакового расчета количества
     /// материала, требуемого для производства продукции
     /// </summary>
    internal class MaterialQuantityCalculation
    {
        /// <summary>
        /// Рассчитывает количество материала, требуемого для производства продукции
        /// </summary>
        /// <param name="idTypeProduct"> Идентификатор типа продукции</param>
        /// <param name="idMaterial"> Идентификатор типа материала</param>
        /// <param name="quantityOfProducts"> Количество продукции, которое необходимо произвести </param>
        /// <param name="param1"> Первый параметр </param>
        /// <param name="param2"> Второй параметр </param>
        /// <returns> Возвращает количество материала </returns>
        public int QuantityOfMaterial(int idTypeProduct, int idMaterial, int quantityOfProducts, double param1, double param2)
        {
            try
            {
                //Параметры продукции должны быть положительные числа
                if (param1 > 0 && param2 > 0 && quantityOfProducts >= 0) 
                { 
                    using(var dbContext = new MasterFloorEntity())
                    {
                        //Находим конкретный коэффициент, который зависит от типа продукции. 
                        var ProductTypeCoefficient = from ProductType in dbContext.ProductType
                                                     where ProductType.id == idTypeProduct
                                                     select new
                                                     {
                                                         ProductType.productTypeCoeff
                                                     };

                        //Находим процент брака материала, который зависит от типа материала.
                        var MaterialScrapPercentage = from MaterialType in dbContext.MaterialType
                                                      where MaterialType.id == idMaterial
                                                      select new
                                                      {
                                                          MaterialType.defectRate
                                                      };

                        //Если нет был найден коэффициент или процент брака материала по заданным условиям
                        if (ProductTypeCoefficient.Equals(null) || MaterialScrapPercentage.Equals(null))
                        {
                            return -1;
                        }
                        else
                        {
                            // Количество необходимого материала на одну единицу продукции рассчитывается как произведение параметров продукции,
                            // умноженное на коэффициент типа продукции.
                            double AmountOfMaterialRequired = param1 * param2 * Convert.ToDouble(ProductTypeCoefficient);

                            //нужно учитывать процент брака материала в зависимости от его типа: с учетом возможного
                            // брака материала необходимое количество материала должно быть увеличено.
                            double MaterialTakingIntoAccDefects = AmountOfMaterialRequired * Convert.ToDouble(MaterialScrapPercentage) + 1;

                            //количество необходимого материала с учетом возможного брака материала
                            return Convert.ToInt32(Math.Round(MaterialTakingIntoAccDefects));
                        }
                    }
                }
                else
                {                    
                    return -1;
                }
            }
            catch 
            {
                return -1;
            }

        }
    }
}
