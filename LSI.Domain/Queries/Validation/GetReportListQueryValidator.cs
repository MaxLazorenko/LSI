using FluentValidation;
using System;

namespace LSI.Domain.Queries.Validation
{
    public sealed class GetReportListQueryValidator: AbstractValidator<GetReportListQuery>
    {
        public GetReportListQueryValidator()
        {
            RuleFor(x => x.RoomName).NotNull().NotEmpty();

            RuleFor(x => x.From).Must(IsDateValid).WithMessage("Invalid from Date");

            RuleFor(x => x.To).Must(IsDateValid).WithMessage("Invalid to Date");
        }

        private bool IsDateValid(string Date)
            => DateTime.TryParse(Date, out var result);
    }
}
