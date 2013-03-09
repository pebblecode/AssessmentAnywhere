﻿namespace AssessmentAnywhere.Models.Assessments
{
    using System;

    public class ResultRow
    {
        public ResultRow(Guid rowId, string surname, string forenames, decimal? result)
            : this(rowId, surname, forenames, result, null, string.Empty)
        {
        }

        public ResultRow(Guid rowId, string surname, string forenames, decimal? result, decimal? percentage, string grade)
        {
            this.RowId = rowId;
            this.Surname = surname;
            this.Forenames = forenames;
            this.Result = result;
            this.Percentage = percentage;
            this.Grade = grade;
        }

        public Guid RowId { get; private set; }

        public string Surname { get; private set; }

        public string Forenames { get; private set; }

        public decimal? Result { get; private set; }

        public decimal? Percentage { get; private set; }

        public string Grade { get; private set; }
    }
}
