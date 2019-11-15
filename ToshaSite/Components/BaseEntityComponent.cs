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

        [Parameter]
        public Entity EntityObject { get; set; }
        [Parameter]
        public bool EditorMode { get; set; }

        protected async void Click()
        {
            if(EditorMode)
            {
                // open modal
            }
            else
            {
                await Js.InvokeVoidAsync("go", EntityObject.Link);
            }
        }
    }
}
