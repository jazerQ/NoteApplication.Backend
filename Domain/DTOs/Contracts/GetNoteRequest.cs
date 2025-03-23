namespace Domain.DTOs.Contracts;

public record GetNoteRequest(
    string? Search,
    string? SortItem,
    string? SortOrder
);


