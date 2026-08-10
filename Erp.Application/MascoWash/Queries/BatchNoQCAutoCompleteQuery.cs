using Erp.Application.MascoWash.Queries;
using MediatR;
using System.Collections.Generic;

public class BatchNoQCAutoCompleteQuery
    : IRequest<List<BatchNoQCAutoCompleteDto>>
{
    public string SearchText { get; set; }

    public BatchNoQCAutoCompleteQuery(string searchText)
    {
        SearchText = searchText;
    }
}