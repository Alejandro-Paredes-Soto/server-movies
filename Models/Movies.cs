﻿namespace server_movies.Models
{
    public class Movies
    {

        public int IdMovie { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public DateTime ReleaseDate { get; set; }

        public string Img { get; set; }

        public string Language {  get; set; }

    }
}
