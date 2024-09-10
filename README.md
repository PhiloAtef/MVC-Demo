now we need to start creating views 

first we pass the model data in the controller that we get from the repository in the BLL.
so for index, in the return view() we pass it the departments since in this case we are working on the departments repository. so we will write in the return of the index return view(departments)

then right click index and create view

then we bind the data to that view using the @model at the start of the view

to do that we need to check first what is the return type of the model data that is being passed through. in our first case, the GETALL function returns an IEnumerable of type department so we add that to the @model

and preferably, add the @model IEnumerable<Department> to the global view imports

then start creating ur view using html

u can call the departments we sent using Model in the razor page 

c# logic using @

inside anchors, add asp-controller and asp-action to deffine anchor routing 

also add asp-route-Hamada to send props or variables along the route


