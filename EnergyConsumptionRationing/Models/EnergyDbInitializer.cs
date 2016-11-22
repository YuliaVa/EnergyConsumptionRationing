using System;
using System.IO;
using System.Web;
using System.Data.Entity;

namespace EnergyConsumptionRationing.Models
{
    public class EnergyDbInitializer : CreateDatabaseIfNotExists<EnergyContext>
    {
        /*protected override void Seed(EnergyContext db)
        {
            int production_number = 10;
            int organization_number = 10;
            int release_number = 100;
            int consumed_number = 100;
            int expense_number = 100;
            string productName, measureUnit;
            string organizationName, formOwnership, address, nameLeader, nameEngineer;
            int totalRelease, yearRelese, quarterRelease;
            int totalConsumed, yearConsumed, quarterConsumed;
            int phoneLeader, phoneEngineer;
            int quarterlyNorm, yearExpense, quarterExpense;

            Random randObj1 = new Random(1);

            //Заполнение таблицы типы продукции
            string[] product_voc = { "Рулетка", "Штангенинструмент", "Линейка", "Микрометр", "Толщинометр" };//словарь названий продукции
            string[] measure_voc = { "Миллиметр", "Сантиметр", "Метр", "Дециметр", "Километр" };//словарь названий единиц измерения
            int count_product_voc = product_voc.GetLength(0);
            int count_measure_voc = measure_voc.GetLength(0);
            for (int prodID = 1; prodID < production_number; prodID++)
            {
                productName = product_voc[randObj1.Next(count_product_voc)];
                measureUnit = measure_voc[randObj1.Next(count_measure_voc)];
                db.TypesProduction.Add(new TypesProduction { ProductionID = prodID, ProductionName = productName, MeasureUnit = measureUnit });
            }

            //Заполнение таблицы организация
            string[] name_voc = { "Иванов В.И.", "Петров К.О.", "Сидоров И.Ф.", "Марков Н.А.", "Васильев С.М.", "Сидоров А.А.", "Соколов Ф.М.", "Гавриленко А.А.", "Попов И.Р.", "Андреев Е.М.", "Лебедев Ф.Я.", "Степанов Г.О." };//словарь ФИО руководителя, инженера
            string[] orgname_voc = { "ИзмерьКа_", "МетрБренд_", "БеларусьПрибор_", "Эталон_", "Элемер_", "ИзТех_" };//словарь названий организаций
            string[] address_voc = { "Полесская_1", "пр.Октября_21", "Железнодорожная_4", "Шоссейная_54", "Пролесская_116", "Хатаевича_75" };//словарь адресов
            string[] form_voc = { "ЗАО", "ОАО", "БеларусьПрибор", "Ассациация", "Союз", "Фонд", "учреждение" };//словарь названий форм собственности
            int count_name_voc = name_voc.GetLength(0);
            int count_orgname_voc = orgname_voc.GetLength(0);
            int count_address_voc = address_voc.GetLength(0);
            int count_form_voc = form_voc.GetLength(0);
            for (int orgID = 1; orgID < organization_number; orgID++)
            {
                nameEngineer = name_voc[randObj1.Next(count_name_voc)];
                nameLeader = name_voc[randObj1.Next(count_name_voc)];
                address = address_voc[randObj1.Next(count_address_voc)];
                organizationName = orgname_voc[randObj1.Next(count_orgname_voc)] + orgID.ToString();
                formOwnership = form_voc[randObj1.Next(count_form_voc)];
                phoneLeader = randObj1.Next(10000, 99999);
                phoneEngineer = randObj1.Next(10000, 99999);
                db.Organization.Add(new Organization { OrganizationID = orgID, OrganizationName = organizationName, FormOwnership = formOwnership, Address = address, NameLeader = nameLeader, PhoneLeader = phoneLeader, NameEngineer = nameEngineer, PhoneEngineer = phoneEngineer });
            }

            //Зполнение таблицы произведено продукции
            for (int releaseID = 1; releaseID < release_number; releaseID++)
            {
                totalRelease = randObj1.Next(1, 100);
                yearRelese = randObj1.Next(1800, 2016);
                quarterRelease = randObj1.Next(1, 4);
                int productionID = randObj1.Next(1, production_number - 1);
                int organizationID = randObj1.Next(1, organization_number - 1);
                db.ReleaseProducts.Add(new ReleaseProducts { ReleaseID = releaseID, ProductionID = productionID, TotalRelease = totalRelease, Year = yearRelese, Quarter = quarterRelease, OrganizationID = organizationID });
            }

            //Заполняем таблицу потребление теплоэнергии
            for (int consumedID = 1; consumedID < consumed_number; consumedID++)
            {
                totalConsumed = randObj1.Next(1, 100);
                yearConsumed = randObj1.Next(1800, 2016);
                quarterConsumed = randObj1.Next(1, 4);
                int productionID = randObj1.Next(1, production_number - 1);
                int organizationID = randObj1.Next(1, organization_number - 1);
                db.ConsumedRelease.Add(new ConsumedRelease { ConsumptionID = consumedID, TotalConsumption = totalConsumed, Year = yearConsumed, Quarter = quarterConsumed, ProductionID = productionID, OrganizationID = organizationID });
            }

            //Заполняем таблицу нормы расхода
            for (int expenseID = 1; expenseID < expense_number; expenseID++)
            {
                quarterlyNorm = randObj1.Next(1, 100);
                yearExpense = randObj1.Next(1800, 2016);
                quarterExpense = randObj1.Next(1, 4);
                int productionID = randObj1.Next(1, production_number - 1);
                int organizationID = randObj1.Next(1, organization_number - 1);
                db.StandartExpense.Add(new StandartExpense { ExpenseID = expenseID, QuarterlyNormEnergyUnit = quarterlyNorm, ProductionID = productionID, Year = yearExpense, Quarter = quarterExpense, OrganizationID = organizationID });
            }
            //сохранение изменений в базу данных,связанную с объектом контекста
            db.SaveChanges();
        }*/

        protected override void Seed(EnergyContext context)
        {
            //Задание пусти к файлу с текстом T-SQL инструкции
            string readPath = HttpContext.Current.Server.MapPath("~") + "/Scripts/EnergyBase/FillDBase.sql";

            //считывание  текста SQL инструкции из внешнего текстового файла
            string SQLstring = "";
            try
            {
                using (StreamReader sr = new StreamReader(readPath, System.Text.Encoding.Default))
                {
                    SQLstring = sr.ReadToEnd();
                }
                //Выполнение T-SQL инструкции
                context.Database.ExecuteSqlCommand(SQLstring);
                base.Seed(context);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}