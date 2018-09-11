using System.Collections.Generic;
using FrontEndModel = TodoApp.FrontEnd.Model;
using CoreEntities = TodoApp.Core.Entities;

namespace TodoApp.FrontEnd.Extensions
{
    internal static class TodoItemMapper
    {
        internal static IList<FrontEndModel.TodoItemModel> ToModel(this IList<CoreEntities.TodoItem> todoItemEntities)
        {
            var result = new List<FrontEndModel.TodoItemModel>();
            foreach (var todoItemEntity in todoItemEntities)
            {
                result.Add(new FrontEndModel.TodoItemModel(
                    todoItemEntity.Id,
                    todoItemEntity.Title,
                    todoItemEntity.Description,
                    todoItemEntity.CreatedAt,
                    todoItemEntity.ClosedAt));
            }

            return result;
        }
    }
}
