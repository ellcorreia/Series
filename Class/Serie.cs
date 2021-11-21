namespace Series
{
    public class Serie : BaseIdentity
    {
        
		private Genre Genre { get; set; }
		private string Title { get; set; }
		private string Description { get; set; }
		private int Year { get; set; }
        private bool Deleted {get; set;}

        
		public Serie(int id, Genre Genre, string Title, string Description, int Year)
		{
			this.Id = id;
			this.Genre = Genre;
			this.Title = Title;
			this.Description = Description;
			this.Year = Year;
            this.Deleted = false;
		}

        public override string ToString()
		{
			
            string retorno = ""; //Return
            retorno += "Genre: " + this.Genre + Environment.NewLine;
            retorno += "Title: " + this.Title + Environment.NewLine;
            retorno += "Description: " + this.Description + Environment.NewLine;
            retorno += "Year: " + this.Year + Environment.NewLine;
            retorno += "Deleted: " + this.Deleted;
			return retorno;
		}

        public string returnTitle()
		{
			return this.Title;
		}

		public int returnId()
		{
			return this.Id;
		}
        public bool returnDeleted()
		{
			return this.Deleted;
		}
        public void Delete() 
        {
            this.Deleted = true;
        }
    }
}