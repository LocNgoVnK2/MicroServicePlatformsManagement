# MicroServicePlatformsManagement
Standard for Microservice Architecture with 2 services ( ASP.NET Web API , Nginx, .NET 7 ,Docker , Kubernetes, RabbitMQ,...)

Structure of your project:
K8S : Kubernetes resources used to deploy an ASP.NET Core web application
![image](https://github.com/LocNgoVnK2/MicroServicePlatformsManagement/assets/77975567/ad55a40d-5f29-46e0-b3e1-4e4604b52f88)
- About Kubernetes : Deployments are used to manage groups of pods and a pod is the basic unit of deployment in Kubernetes. A pod can contain one or more containers. Each deployment has a desired state, which is the number and configuration of pods that you want to run.
Kubernetes will automatically create and manage pods to achieve the desired state. Auto scaling: Kubernetes can automatically adjust the number of pods to meet the needs of the application. This can be done based on factors such as load, number of requests, and resource usage.
- For my case: I have designed database with 2 table with relationship One platform have Many commands.
![image](https://github.com/LocNgoVnK2/MicroServicePlatformsManagement/assets/77975567/d69ea76a-b5fd-46aa-ae8a-4591e3270b5f)![image](https://github.com/LocNgoVnK2/MicroServicePlatformsManagement/assets/77975567/b8b5d82f-7874-4c55-963b-77b95559dd5a)

Beside some informations about pods and deployments of project:
![image](https://github.com/LocNgoVnK2/MicroServicePlatformsManagement/assets/77975567/74b7cf58-1946-40b7-a367-6f4e63c221d4)
![image](https://github.com/LocNgoVnK2/MicroServicePlatformsManagement/assets/77975567/e1e0c0c0-dd3e-43d0-bb39-48372ba9c5b4)

Live Demo : 





