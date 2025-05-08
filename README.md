# YYvMicroserviceAssignment


# API Gateway

## Overview
The **API Gateway** project serves as a centralized entry point for managing and routing requests to various microservices in the system. It is built using `.NET 6` and leverages **Ocelot** for API Gateway functionality. This project also integrates with service discovery tools like **Consul** and **Eureka**, and supports advanced features such as authentication, load balancing, and resiliency.

## Features
- **Routing and Aggregation**: Routes requests to appropriate microservices.
- **Service Discovery**: Uses Consul and Eureka for dynamic service registration and discovery.
- **Authentication and Authorization**: Integrates with a custom JWT Authentication Manager.
- **Resiliency**: Implements retry policies and circuit breakers using Polly.
- **Swagger Integration**: Provides API documentation for the gateway using Swagger for Ocelot.

## Technologies Used
- **.NET 6**
- **Ocelot**: API Gateway library.
- **Consul** and **Eureka**: Service discovery providers.
- **Polly**: Resiliency and fault-handling library.
- **Steeltoe**: Integration with Spring Cloud services.
- **Docker**: Supports containerized deployment.

## Project Structure
- **ApiGateway**: The main project implementing the API Gateway.
- **JwtAuthenticationManager**: A referenced project for handling JWT-based authentication.

## Prerequisites
- **.NET 6 SDK**
- **Docker** (for containerized deployment)
- **Consul** or **Eureka** (for service discovery)
   
