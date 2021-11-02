using FluentValidation;
using UdemyBlogProject.DTO;

namespace UdemyBlogProject.BusinessLayer.ValidationRules.FluentValidation
{
    public class CommentAddValidator : AbstractValidator<CommentAddDto>
    {
        public CommentAddValidator()
        {
            RuleFor(I => I.AuthorEmail).NotEmpty().WithMessage("Eposta alanı boş geçilemez");
            RuleFor(I => I.AuthorName).NotEmpty().WithMessage("Yazar adı alanı boş geçilemez");
            RuleFor(I => I.Description).NotEmpty().WithMessage("Yorum alanı boş geçilemez");
        }
    }
}