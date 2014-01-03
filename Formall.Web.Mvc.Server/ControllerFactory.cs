using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Formall.Web.Mvc
{
    public class ControllerFactory : DefaultControllerFactory
    {
        protected override Type GetControllerType(RequestContext requestContext, string controllerName)
        {
            var controllerType = base.GetControllerType(requestContext, controllerName);

            if (controllerType == null || controllerType == typeof(Formall.Web.Mvc.Controllers.DomainController))
            {
                var path = requestContext.HttpContext.Request.Path;

                var pathSplit = path.Split(new [] { '/' }, StringSplitOptions.RemoveEmptyEntries);

                var actionIndex = pathSplit
                    .Select((item, index) => new { Action = item, Index = index })
                    .Where(o => o.Action.Length > 1 && o.Action[0] == '$')
                    .LastOrDefault();

                var action = "Index";
                
                if (actionIndex != null)
                {
                    action = actionIndex.Action;

                    action = action.TrimStart('$');

                    var tokens = action.Split(new [] { '-' }, StringSplitOptions.RemoveEmptyEntries);

                    action = string.Concat(tokens.Select(token => token.Substring(0, 1).ToUpperInvariant() + token.Substring(1).ToLowerInvariant()));

                    path = string.Join("/", pathSplit.Take(actionIndex.Index));
                }

                controllerType = typeof(Formall.Web.Mvc.Controllers.DomainController);
                requestContext.RouteData.Values["action"] = action;
                requestContext.RouteData.Values["path"] = path;
                return controllerType;
            }


            var areaName = requestContext.RouteData.Values["area"] as string;
            var actionName = requestContext.RouteData.Values["action"] as string;
            var httpMethod = requestContext.HttpContext.Request.HttpMethod.ToUpperInvariant();

            HttpVerbs httpVerb;
            if (!System.Enum.TryParse<HttpVerbs>(requestContext.HttpContext.Request.HttpMethod, true, out httpVerb))
                httpVerb = HttpVerbs.Get;

            /*switch (areaName)
            {
                case "Data":
                    {
                        CrudActions crudAction;

                        if (string.IsNullOrEmpty(actionName) || !System.Enum.TryParse<CrudActions>(actionName, true, out crudAction))
                            switch (httpVerb)
                            {
                                case HttpVerbs.Delete:
                                    crudAction = CrudActions.Delete;
                                    break;

                                case HttpVerbs.Get:
                                    crudAction = CrudActions.Select;
                                    break;

                                case HttpVerbs.Patch:
                                    crudAction = CrudActions.Update;
                                    requestContext.RouteData.Values["patch"] = true;
                                    break;

                                case HttpVerbs.Post:
                                    crudAction = CrudActions.Create;
                                    break;

                                case HttpVerbs.Put:
                                    crudAction = CrudActions.Update;
                                    break;

                                case HttpVerbs.Options:
                                    requestContext.RouteData.Values["action"] = "Options";
                                    return controllerType;

                                default:
                                    crudAction = CrudActions.Default;
                                    break;
                            }

                        switch (crudAction)
                        {
                            case CrudActions.Update:
                                // fix patch
                                var patchValue = requestContext.RouteData.Values["patch"];
                                if (patchValue == null || patchValue.GetType() != typeof(bool))
                                    requestContext.RouteData.Values["patch"] = true;
                                break;
                        }

                        if (actionName == null)
                        {
                            actionName = System.Enum.GetName(typeof(CrudActions), crudAction);

                            requestContext.RouteData.Values["action"] = actionName;
                        }
                    }
                    break;
            }*/

            return controllerType;
        }
    }
}