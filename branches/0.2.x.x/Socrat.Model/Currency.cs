namespace Socrat.Model
{
    public class Currency: Entity
    {

        private string _Alias;
        public string Alias
        {
            get { return _Alias; }
            set { SetField(ref _Alias, value, () => Alias, () => Title); }
        }

        private string _Comment;
        public string Comment
        {
            get { return _Comment; }
            set { SetField(ref _Comment, value, () => Comment); }
        }

        protected override string GetTitle()
        {
            return "Валюта: " + Alias;
        }
    }
}