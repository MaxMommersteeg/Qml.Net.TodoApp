using System.Collections.Generic;
using FrontEndModel = TodoApp.FrontEnd.Model;
using CoreEntities = TodoApp.Core.Entities;

namespace TodoApp.FrontEnd.Extensions
{
    internal static class TodoItemMapper
    {
        internal static List<FrontEndModel.TodoItemModel> ToModel(this List<CoreEntities.TodoItem> todoItemEntities)
        {
            var result = new List<FrontEndModel.TodoItemModel>();
            foreach (var todoItemEntity in todoItemEntities)
            {
                result.Add(new FrontEndModel.TodoItemModel(
                    todoItemEntity.Id,
                    todoItemEntity.Title,
                    todoItemEntity.CreatedAt,
                    todoItemEntity.CompletedAt));
            }

            return result;
        }
    }
}
