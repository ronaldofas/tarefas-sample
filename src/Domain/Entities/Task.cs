namespace Domain.Entities
{
    public class Task
    {
        public int Id { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public DateTime DueDate { get; private set; }
        public DateTime ChangeDate { get; private set; }
        public virtual User User { get; private set; }

        public Task(int id, string title, string description)
        {
            ValidateTitle(title);
            ValidateDescription(description);
            Id = id;
            Title = title;
            Description = description;
            ChangeDate = DateTime.Now;
        }


        public bool ChangeTitle (string title)
        {
            Title = title;
            UpdateChangeDate();
            return true;
        }

        public bool ChangeDescription(string description)
        {
            Description = description;
            UpdateChangeDate();
            return true;
        }

        public bool ChangeDueDate(DateTime dueDate)
        {
            DueDate = dueDate;
            UpdateChangeDate();
            return true;
        }

        private void UpdateChangeDate()
        {
            ChangeDate = DateTime.Now;
        }
        private void ValidateTitle(string title)
        {
            if (String.IsNullOrEmpty(title))
            {
                throw new ArgumentException("Título inválido!");
            }

            if (title.Length < 8)
            {
                throw new ArgumentException("Título deve ter pelo menos oito caracteres!");
            }
        }

        private void ValidateDescription(string description)
        {
            if (String.IsNullOrEmpty(description))
            {
                throw new ArgumentException("Descrição inválida!");
            }

            if (description.Length < 15)
            {
                throw new ArgumentException("Descrição deve ter pelo menos quinze caracteres!");
            }
        }
    }
}
