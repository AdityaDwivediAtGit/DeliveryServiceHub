# DeliveryServiceHub

This repository contains a demo project for a delivery service API that integrates with fictional delivery partners ShipRocket and Porter. The project is divided into several sub-projects:

- **DeliveryService.Common**: Main common API consisting of controllers, request/response mappers, and HTTP requesters.
- **DeliveryService.Data**: Data and repository layer for accessing and managing data from SQL Server.
- **DeliveryService.Porter**: Demo application to respond to requests as if it were the Porter delivery partner.
- **DeliveryService.ShipRocket**: Demo application to respond to requests as if it were the ShipRocket delivery partner.
- **docker-compose**: Docker Compose file managing all projects, including network ports and environmental variables.

## Getting Started

To get started with this project, follow these steps:

1. Clone the repository: `gh repo clone AdityaDwivediAtGit/DeliveryServiceHub`
2. Navigate to the cloned repository: `cd DeliveryServiceHub`
3. Update the connection string in `Program.cs` and API URLs in `appsettings.json` with your local host IP address from mine (192.168.68.171 in this case). You can simply execute `ifconfig` for knowing this on a windows machine.
4. Run the project using Docker Compose: `docker-compose up`

## Project Structure

The project is structured as follows:

- **DeliveryService.Common**: Contains the main common API logic, including controllers, request/response mappers, and HTTP requesters.
- **DeliveryService.Data**: Contains the data and repository layer for accessing and managing data from SQL Server.
- **DeliveryService.Porter**: Contains the demo application to respond to requests as if it were the Porter delivery partner.
- **DeliveryService.ShipRocket**: Contains the demo application to respond to requests as if it were the ShipRocket delivery partner.
- **docker-compose**: Contains the Docker Compose file managing all projects, including network ports and environmental variables.

## Contributing

Contributions to this project are welcome. Please fork the repository and submit a pull request with your changes. For major changes, please open an issue first to discuss the proposed changes.

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.
