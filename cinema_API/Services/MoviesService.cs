﻿using cinema_API.Models;
using cinema_API.Repositories;

namespace cinema_API.Services
{
    public class MoviesService : IMoviesService
    {
        IMoviesRepository _repository;
        public MoviesService(IMoviesRepository repository)
        {
            _repository = repository;
        }
        public IEnumerable<MovieSessionShort> GetAll(Dictionary<string, string> dict)
        {
            return _repository.GetAll(dict);
        }
        public MovieSessionFull GetOne(int id)
        {
            return _repository.GetOne(id);
        }
    }
}
