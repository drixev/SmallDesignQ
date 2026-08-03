using GenerateService.Application.DTOs;

namespace GenerateService.Application.Extensions;

public static class PaginationExtensions
{
    public static PagedResponse ToPagedResponse(this IReadOnlyCollection<GenerateResponse> source, int page, int pageSize)
    {
        var items = source.Skip((page - 1) * pageSize).Take(pageSize).ToList();

        return new PagedResponse
        {
            Items = items,
            Page = page,
            PageSize = pageSize,
            TotalItems = source.Count,
            TotalPages = (int)Math.Ceiling(source.Count / (double)pageSize)
        };
    }
}
