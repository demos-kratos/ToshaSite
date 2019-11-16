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
        [Inject]
        protected IJSRuntime Js { get; set; }

        [Inject]
        protected IModalService Modals { get; set; }

        [Parameter]
        public Entity EntityObject { get; set; }
        [Parameter]
        public bool EditorMode { get; set; }
        [Parameter]
        public Action<Entity> EditCompleted { get; set; }
        
        protected async void Click()
        {
            if(EditorMode)
            {
                var title = EntityObject == null ? "Создание" : "Редактирование";
                var parameters = new ModalParameters();
                parameters.Add("EntityObject", EntityObject);
                parameters.Add("EditCompleted", EditCompleted);
                Modals.Show<EntityEditor>(title, parameters);
            }
            else
            {
                await Js.InvokeVoidAsync("go", EntityObject.Link);
            }
        }
    }
}
