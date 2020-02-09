using Blazored.Modal;
using Blazored.Modal.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToshaSite.Data;

namespace ToshaSite.Components
{
    public abstract class BaseEntityComponent : ComponentBase
    {
        [Inject] protected IJSRuntime Js { get; set; }
        [Inject] protected IModalService Modals { get; set; }
        [Inject] protected NavigationManager Navigation { get; set; }
        [Parameter] public Entity EntityObject { get; set; }
        [Parameter] public bool EditorMode { get; set; }

        protected void Click()
        {
            if (EditorMode)
            {
                var title = EntityObject == null ? "Создание" : "Редактирование";
                var parameters = new ModalParameters();
                parameters.Add("EntityObject", EntityObject ?? new Entity());
                parameters.Add("Creating", EntityObject == null);
                Modals.Show<EntityEditor>(title, parameters);
            }
            else
            {
                if(EntityObject.Link != null)
                    Navigation.NavigateTo(EntityObject.Link);
            }
        }
    }
}
