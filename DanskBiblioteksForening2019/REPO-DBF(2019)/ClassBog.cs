using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REPO_DBF_2019_
{
    /// <summary>
    /// This Class Handles the fields and properties for each book.
    /// </summary>
    public class ClassBog : ClassNotify, ICloneable
    {
        
        /// <summary>
        /// Default Constructor.
        /// </summary>
        public ClassBog()
        {
            id = 0;
            isbnNr = new ClassISBN();
            titel = new ClassTitle();
            forfatter = new ClassAuthor();
            forlag = new ClassPublisher();
            genre = new ClassGenre();
            type = new ClassType();
            rentdate = new Classudlaan();
            pris = 0;
        }

        public ClassBog(int inId, ClassISBN inISBN, ClassTitle inTitle, ClassAuthor inAuthor, ClassPublisher inPublisher,
                        ClassGenre inGenre, ClassType inType, Classudlaan inRentDate, decimal inPris)
        {
            id = inId;
            isbnNr = inISBN;
            titel = inTitle;
            forfatter = inAuthor;
            forlag = inPublisher;
            genre = inGenre;
            type = inType;
            rentdate = inRentDate;
            pris = inPris;
        }


        //Private Fields holding values
        #region
        private int _id;
        private ClassISBN _isbnNr;
        private ClassTitle _titel;
        private ClassAuthor _forfatter;
        private ClassPublisher _forlag;
        private ClassGenre _genre;
        private ClassType _type;
        private Classudlaan _rentdate;
        private decimal _pris;
        #endregion
        #region constructors


        #endregion
        #region Properties

        public Classudlaan rentdate
        {
            get { return _rentdate; }
            set
            {
                if (value != _rentdate)
                {
                    _rentdate = value;
                    Notify("rentDate");
                }
            }
        }
        public int id
        {
            get { return _id; }
            set
            {
                if (value != _id)
                {
                    _id = value;
                    Notify("id");

                }
            }
        }   
        public ClassISBN isbnNr
        {
            get { return _isbnNr; }
            set
            {
                if (value != _isbnNr)
                {
                    _isbnNr = value;
                    Notify("isbnNr");

                }
            }
        }


        public ClassTitle titel
        {
            get { return _titel; }
            set
            {
                if (value != _titel)
                {
                    _titel = value;
                    Notify("titel");
                }
            }
        }




        public ClassAuthor forfatter
        {
            get { return _forfatter; }
            set
            {
                if (value != _forfatter)
                {
                    _forfatter = value;
                    Notify("forfatter");
                }
            }
        }



        public ClassPublisher forlag
        {
            get { return _forlag; }
            set
            {
                if (value != _forlag)
                {
                    _forlag = value;
                    Notify("forlag");
                }
            }
        }

        public ClassGenre genre
        {
            get { return _genre; }
            set
            {
                if (value != _genre)
                {
                    _genre = value;
                    Notify("genre");
                }
            }
        }

        public ClassType type
        {
            get { return _type; }
            set
            {
                if (value != _type)
                {
                    _type = value;
                    Notify("type");
                }
            }
        }

        public decimal pris
        {
            get { return _pris; }
            set
            {
                if (value != _pris)
                {
                    _pris = value;
                    Notify("pris");
                }
            }
        }

        public object Clone()
        {
            return new ClassBog(this.id, this.isbnNr, this.titel, this.forfatter,
                                this.forlag, this.genre, this.type, this.rentdate, this.pris);
        }
        #endregion
    }
}
