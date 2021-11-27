namespace Task02
{
    class Good
    {
        public string Name { get; private set; }

        public Good(string name)
        {
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
