namespace Training.DomainClasses
{
    class Negation<TItem> : Criteria<TItem>
    {
        private readonly Criteria<TItem> _critreria;

        public Negation(Criteria<TItem> critreria)
        {
            _critreria = critreria;
        }

        public bool IsSatisfiedBy(TItem item)
        {
            return !_critreria.IsSatisfiedBy(item);
        }
    }
}