﻿namespace CodeStudy.Misc.Autofacs
{
    public interface IDatabase
    {
        string Name { get; }
        void Select(string commandText);
        void Insert(string commandText);
        void Update(string commandText);
        void Delete(string commandText);
    }
}
