﻿using REPO_DBF_2019_;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DB_IO_DBF_2019_
{
    public class ClassDbfDB : ClassDB
    {

        public ClassDbfDB()
        {
            SetCon("Server=10.205.44.39,49172;Database=DBF_2019;User Id=AspIT;Password=Server2012;");
        }
        
        public ObservableCollection<ClassBog> GetAllBooks()
        {
            ObservableCollection<ClassBog> CB = new ObservableCollection<ClassBog>();

            DataTable dt = DbReturnDataTable("SELECT * FROM Books");
            foreach(DataRow row in dt.Rows)
            {
                ClassBog bog = new ClassBog();

                bog.id = Convert.ToInt32(row["id"].ToString());
                bog.isbnNr = GetISBNFromDB(row["isbnID"].ToString());
                bog.titel = GetTitleFromDB(row["titelID"].ToString());
                bog.forfatter = GetAuthorFromDB(row["forfatterID"].ToString());
                bog.forlag = GetPublisherFromDB(row["forlagID"].ToString());
                bog.genre = GetGenreFromDB(row["genreID"].ToString());
                bog.type = GetTypeFromDB(row["typeID"].ToString());
                bog.pris = Convert.ToDecimal(row["pris"].ToString());
                CB.Add(bog);
            }
            return CB;
        }

        public ObservableCollection<ClassBog> GetAllBooksLike(string search)
        {
            ObservableCollection<ClassBog> CB = new ObservableCollection<ClassBog>();

            DataTable dt = DbReturnDataTable($"SELECT dbo.Titel.titel, dbo.Books.isbnID, dbo.Books.forfatterID, dbo.Books.forlagID, dbo.Books.genreID, dbo.Books.typeID, dbo.Books.pris, dbo.Books.id, dbo.Books.titelID" +
                "FROM dbo.Books INNER JOIN" +
                "dbo.Titel ON dbo.Books.titelID = dbo.Titel.id"+
                $"WHERE (dbo.Titel.titel = '*{search}*')");
            foreach (DataRow row in dt.Rows)
            {
                ClassBog bog = new ClassBog();

                bog.id = Convert.ToInt32(row["id"].ToString());
                bog.isbnNr = GetISBNFromDB(row["isbnID"].ToString());
                bog.titel = GetTitleFromDB(row["titelID"].ToString());
                bog.forfatter = GetAuthorFromDB(row["forfatterID"].ToString());
                bog.forlag = GetPublisherFromDB(row["forlagID"].ToString());
                bog.genre = GetGenreFromDB(row["genreID"].ToString());
                bog.type = GetTypeFromDB(row["typeID"].ToString());
                bog.pris = Convert.ToDecimal(row["pris"].ToString());
                CB.Add(bog);
            }

            return CB;
        }
        public ObservableCollection<ClassBog> GetAllLentToUser(string personid)
        {
            DataTable dt = DbReturnDataTable("SELECT dbo.Books.id, dbo.Type.TypeNavn, dbo.Titel.titel," +
                " dbo.Genre.genreType, dbo.Forfatter.forfatter, dbo.Forlag.forlagsNavn, dbo.ISBNnr.isbnNr, dbo.Udlaan.udlaansStatus" +
                "FROM dbo.Udlaan RIGHT OUTER JOIN dbo.Books INNER JOIN" +
                " dbo.Forfatter ON dbo.Books.forfatterID = dbo.Forfatter.id INNER JOIN" +
                " dbo.Forlag ON dbo.Books.forlagID = dbo.Forlag.id INNER JOIN" +
                " dbo.Genre ON dbo.Books.genreID = dbo.Genre.id INNER JOIN" +
                " dbo.ISBNnr ON dbo.Books.isbnID = dbo.ISBNnr.id INNER JOIN" +
                " dbo.Titel ON dbo.Books.titelID = dbo.Titel.id INNER JOIN" +
                " dbo.Type ON dbo.Books.typeID = dbo.Type.id ON dbo.Udlaan.bookID = dbo.Books.id" +
                $"WHERE(dbo.Udlaan.personID = '{personid}') AND(dbo.Udlaan.udlaansStatus = 2)");
            ObservableCollection<ClassBog> listCB = new ObservableCollection<ClassBog>();
            foreach (DataRow row in dt.Rows)
            {
                Classudlaan CUD = new Classudlaan();

                

            }
            return listCB;
        }

        public ObservableCollection<ClassBog> GetAvailbleBooks()
        {
            ObservableCollection<ClassBog> listCB = new ObservableCollection<ClassBog>();
            DataTable dt = DbReturnDataTable($"SELECT dbo.Books.titelID, dbo.Books.isbnID, dbo.Books.forfatterID, dbo.Books.forlagID, dbo.Books.genreID, dbo.Books.typeID, dbo.Books.pris, dbo.Books.id, dbo.UdlaansStatus.status"+
                         "FROM dbo.Books INNER JOIN"+
                         "dbo.Udlaan ON dbo.Books.id = dbo.Udlaan.bookID INNER JOIN"+
                         "dbo.UdlaansStatus ON dbo.Udlaan.udlaansStatus = dbo.UdlaansStatus.id"+
                         "WHERE(dbo.Udlaan.udlaansStatus = 2)");

            foreach(DataRow row in dt.Rows)
            {
                ClassBog bog = new ClassBog();

                bog.id = Convert.ToInt32(row["id"].ToString());
                bog.isbnNr = GetISBNFromDB(row["isbnID"].ToString());
                bog.titel = GetTitleFromDB(row["titelID"].ToString());
                bog.forfatter = GetAuthorFromDB(row["forfatterID"].ToString());
                bog.forlag = GetPublisherFromDB(row["forlagID"].ToString());
                bog.genre = GetGenreFromDB(row["genreID"].ToString());
                bog.type = GetTypeFromDB(row["typeID"].ToString());
                bog.pris = Convert.ToDecimal(row["pris"].ToString());
                listCB.Add(bog);
            }

            return listCB;
        }

        public void UpdateTheLendingStatus(string id, bool status)
        {

        }
        public ClassUser GetUser(string cprNr, string Password)
        {
            string strsql = "SELECT dbo.Person.navn, dbo.Person.adresse, dbo.PersonTelefon.telefonnummer, dbo.PersonMail.mailAdr, " +
                "dbo.Person.rolle FROM dbo.Access LEFT OUTER JOIN" +
                " dbo.Person ON dbo.Access.userId = dbo.Person.id LEFT OUTER JOIN" +
                " dbo.PersonTelefon ON dbo.Person.id = dbo.PersonTelefon.personID LEFT OUTER JOIN" +
                " dbo.PersonMail ON dbo.Person.id = dbo.PersonMail.personID" +
                $"WHERE(dbo.Access.cprNr = '{cprNr}') AND(dbo.Access.password = '{Password}')";
            ClassUser CU = new ClassUser();
            DataTable dt = DbReturnDataTable(strsql);
            foreach (DataRow row in dt.Rows)
            {
                CU = new ClassUser();
                CU.userName = row["cprNr"].ToString();
                CU.password = row["password"].ToString();       
                CU.navn = row["navn"].ToString();
                CU.adresse = row["adresse"].ToString();
                CU.telefon = row["navn"].ToString();
                CU.mail = row["navn"].ToString();
                CU.rolle = row["navn"].ToString();
            }

            return CU;
        }        

        public void UpdateBook(ClassBog CB)
        {
            ExecuteNonQuery($"");
        }

        #region GetBooksInfo

        public ObservableCollection<ClassTitle> GetTitles()
        {
            ObservableCollection<ClassTitle> cTitles = new ObservableCollection<ClassTitle>();
            string sqlQuery = "SELECT * FROM Titel";
            DataTable dataTable = DbReturnDataTable(sqlQuery);

            foreach (DataRow row in dataTable.Rows)
            {
                ClassTitle title = new ClassTitle();
                title.title = row["titel"].ToString();
                title.id = row["id"].ToString();
                cTitles.Add(title);
            }

            return cTitles;
        }
        public ObservableCollection<ClassAuthor> GetAuthors()
        {
            ObservableCollection<ClassAuthor> cAuthors = new ObservableCollection<ClassAuthor>();
            string sqlQuery = "SELECT * FROM Forfatter";
            DataTable dataTable = DbReturnDataTable(sqlQuery);

            foreach (DataRow row in dataTable.Rows)
            {
                ClassAuthor authors = new ClassAuthor();
                authors.author = row["forfatter"].ToString();
                authors.id = row["id"].ToString();
                cAuthors.Add(authors);
            }

            return cAuthors;
        }
        public ObservableCollection<ClassISBN> GetISBNs()
        {
            ObservableCollection<ClassISBN> cISBN = new ObservableCollection<ClassISBN>();
            string sqlQuery = "SELECT * FROM ISBNnr";
            DataTable dataTable = DbReturnDataTable(sqlQuery);

            foreach (DataRow row in dataTable.Rows)
            {
                ClassISBN isbn = new ClassISBN();
                isbn.ISBN = row["isbnNr"].ToString();
                isbn.id = row["id"].ToString();
                cISBN.Add(isbn);
            }

            return cISBN;
        }
        public ObservableCollection<ClassPublisher> GetPublishers()
        {
            ObservableCollection<ClassPublisher> cPublisher = new ObservableCollection<ClassPublisher>();
            string sqlQuery = "SELECT * FROM Forlag";
            DataTable dataTable = DbReturnDataTable(sqlQuery);

            foreach (DataRow row in dataTable.Rows)
            {
                ClassPublisher publishers = new ClassPublisher();
                publishers.publisher = row["forlagsNavn"].ToString();
                publishers.id = row["id"].ToString();
                cPublisher.Add(publishers);
            }

            return cPublisher;
        }
        public ObservableCollection<ClassType> GetTypes()
        {
            ObservableCollection<ClassType> cTypes = new ObservableCollection<ClassType>();
            string sqlQuery = "SELECT * FROM Type";
            DataTable dataTable = DbReturnDataTable(sqlQuery);

            foreach (DataRow row in dataTable.Rows)
            {
                ClassType types = new ClassType();
                types.type = row["TypeNavn"].ToString();
                types.id = row["id"].ToString();
                cTypes.Add(types);
            }

            return cTypes;
        }
        public ObservableCollection<ClassGenre> GetGenre()
        {
            ObservableCollection<ClassGenre> cGenre = new ObservableCollection<ClassGenre>();
            string sqlQuery = "SELECT * FROM Genre";
            DataTable dataTable = DbReturnDataTable(sqlQuery);

            foreach (DataRow row in dataTable.Rows)
            {
                ClassGenre genre = new ClassGenre();
                genre.genre = row["genreType"].ToString();
                genre.id = row["id"].ToString();
                cGenre.Add(genre);
            }

            return cGenre;
        }
        public ObservableCollection<decimal> GetPrices()
        {
            ObservableCollection<decimal> cPrice = new ObservableCollection<decimal>();
            string sqlQuery = "SELECT * FROM Books";
            DataTable dataTable = DbReturnDataTable(sqlQuery);

            foreach (DataRow row in dataTable.Rows)
            {
                cPrice.Add(Convert.ToDecimal(row["pris"].ToString()));
            }

            return cPrice;
        }
        #endregion

        #region GetBookInfo

        private ClassAuthor GetAuthorFromDB(string inID)
        {
            DataTable dt = DbReturnDataTable($"SELECT * FROM Forfatter WHERE id = {inID}");
            ClassAuthor CA = new ClassAuthor();

            foreach(DataRow row in dt.Rows)
            {
                CA.id = row["id"].ToString();
                CA.author = row["forfatter"].ToString();
            }

            return CA;
        }

        private ClassGenre GetGenreFromDB(string inID)
        {
            DataTable dt = DbReturnDataTable($"SELECT * FROM Genre WHERE id = {inID}");
            ClassGenre CG = new ClassGenre();

            foreach (DataRow row in dt.Rows)
            {
                CG.id = row["id"].ToString();
                CG.genre = row["genreType"].ToString();
            }

            return CG;
        }

        private ClassISBN GetISBNFromDB(string inID)
        {
            DataTable dt = DbReturnDataTable($"SELECT * FROM ISBNnr WHERE id = {inID}");
            ClassISBN CI = new ClassISBN();

            foreach (DataRow row in dt.Rows)
            {
                CI.id = row["id"].ToString();
                CI.ISBN = row["isbnNr"].ToString();
            }

            return CI;
        }

        private ClassPublisher GetPublisherFromDB(string inID)
        {
            DataTable dt = DbReturnDataTable($"SELECT * FROM Forlag WHERE id = {inID}");
            ClassPublisher CP = new ClassPublisher();

            foreach (DataRow row in dt.Rows)
            {
                CP.id = row["id"].ToString();
                CP.publisher = row["forlagsNavn"].ToString();
            }

            return CP;
        }

        private ClassTitle GetTitleFromDB(string inID)
        {
            DataTable dt = DbReturnDataTable($"SELECT * FROM Titel WHERE id = {inID}");
            ClassTitle CT = new ClassTitle();

            foreach (DataRow row in dt.Rows)
            {
                CT.id = row["id"].ToString();
                CT.title = row["titel"].ToString();
            }

            return CT;
        }

        private ClassType GetTypeFromDB(string inID)
        {
            DataTable dt = DbReturnDataTable($"SELECT * FROM Type WHERE id = {inID}");
            ClassType CT = new ClassType();

            foreach (DataRow row in dt.Rows)
            {
                CT.id = row["id"].ToString();
                CT.type = row["TypeNavn"].ToString();
            }

            return CT;
        }

        #endregion

        public void InsertTitleIntoDB(ClassTitle inTitle)
        {
            ExecuteNonQuery($"INSERT INTO Titel (title) VALUES('{inTitle.title}')");
        }

        public void InsertAuthorIntoDB(ClassAuthor inAuthor)
        {
            ExecuteNonQuery($"INSERT INTO Forfatter (forfatter) VALUES('{inAuthor.author}')");
        }

        public void InsertGenreIntoDB(ClassGenre inGenre)
        {
            ExecuteNonQuery($"INSERT INTO Genre (genreType) VALUES('{inGenre.genre}')");
        }

        public void InsertISBNIntoDB(ClassISBN inISBN)
        {
            ExecuteNonQuery($"INSERT INTO ISBNnr (isbnNr) VALUES ('{inISBN.ISBN}')");
        }

        public void InsertPublisherIntoDB(ClassPublisher inPublisher)
        {
            ExecuteNonQuery($"INSERT INTO Forlag (forlagsNavn) VALUES ('{inPublisher.publisher}')");
        }

        public void InsertTypeIntoDB(ClassType inType)
        {
            ExecuteNonQuery($"INSERT INTO Type (TypeNavn) VALUES ('{inType.type}')");
        }

       

        #region UpdateBookInfo

        public void UpdateTitleInDB(ClassTitle inTitle)
        {
            ExecuteNonQuery($"UPDATE Titel SET titel = '{inTitle.title}' WHERE id = {inTitle.id}");
        }

        public void UpdateAuthorInDB(ClassAuthor inAuthor)
        {
            ExecuteNonQuery($"UPDATE Forfatter SET forfatter = '{inAuthor.author}' WHERE id = {inAuthor.id}");
        }

        public void UpdatePublisherInDB(ClassPublisher inPublisher)
        {
            ExecuteNonQuery($"UPDATE Forlag SET forlagsNavn = '{inPublisher.publisher}' WHERE id = {inPublisher.id}");
        }

        public void UpdateGenreInDB(ClassGenre inGenre)
        {
            ExecuteNonQuery($"UPDATE Genre SET genreType = '{inGenre.genre}' WHERE id = {inGenre.id}");
        }

        public void UpdateISBNInDB(ClassISBN inISBN)
        {
            ExecuteNonQuery($"UPDATE ISBNnr SET isbnNr = '{inISBN.ISBN}' WHERE id = {inISBN.id}");
        }

        public void UpdateTypeInDB(ClassType inType)
        {
            ExecuteNonQuery($"UPDATE Type SET TypeNavn = '{inType.type}' WHERE id = {inType.id}");
        }
        #endregion
    }
}
