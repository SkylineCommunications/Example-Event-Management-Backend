# Skyline.DataMiner.Learning.EventManagement

## About

An example backend abstraction for an event management solution. This NuGet package provides a lightweight, extensible DataMiner-compatible scaffold for handling, storing, and integrating events using DataMiner's DOM (DataMiner Object Model) framework.

This example demonstrates best practices for building DataMiner backend solutions with:
- Strongly-typed domain models
- Repository pattern for data access
- DOM integration for persistent storage
- Clean API surface for consuming applications

## Features

- **Event Management Models**: Comprehensive event data model including status, type, language, and audio type classifications
- **API Helper**: Simple connection-based API for accessing event repositories
- **DOM Integration**: Automatic persistence using DataMiner Object Model with SDM mapper support
- **Bulk Operations**: Repository pattern supporting efficient bulk read/write operations
- **Type Safety**: Strongly-typed models with enum-based status and type management

## Getting Started

### Installation

Install the NuGet package in your DataMiner Automation script or solution:

```bash
Install-Package Skyline.DataMiner.Learning.EventMangement
```

### Basic Usage

```csharp
using Skyline.DataMiner.Learning.EventManagement.ApiHelpers;
using Skyline.DataMiner.Learning.EventManagement.Models;

// Initialize the API helper with your DataMiner connection
var eventApi = new EventApiHelper(engine.GetUserConnection());

// Create a new event
var newEvent = new Event
{
    Identifier = Guid.NewGuid().ToString(),
    Name = "Skyline Empower 2025",
    Type = EventType.Advanced,
    Status = EventStatus.Requested,
    StartDate = DateTime.Now.AddMonths(1),
    EndDate = DateTime.Now.AddMonths(1).AddDays(3)
};

// Store the event
eventApi.Events.Create(newEvent);

// Retrieve all events
var allEvents = eventApi.Events.Read(new TRUEFilterElement<Event>());

// Update an event
newEvent.Status = EventStatus.InProgress;
eventApi.Events.Update(newEvent);
```

### About DataMiner

DataMiner is a transformational platform that provides vendor-independent control and monitoring of devices and services. Out of the box and by design, it addresses key challenges such as security, complexity, multi-cloud, and much more. It has a pronounced open architecture and powerful capabilities enabling users to evolve easily and continuously.

The foundation of DataMiner is its powerful and versatile data acquisition and control layer. With DataMiner, there are no restrictions to what data users can access. Data sources may reside on premises, in the cloud, or in a hybrid setup.

A unique catalog of 7000+ connectors already exists. In addition, you can leverage DataMiner Development Packages to build your own connectors (also known as "protocols" or "drivers").

> **Note**
> See also: [About DataMiner](https://aka.dataminer.services/about-dataminer).

### About Skyline Communications

At Skyline Communications, we deal in world-class solutions that are deployed by leading companies around the globe. Check out [our proven track record](https://aka.dataminer.services/about-skyline) and see how we make our customers' lives easier by empowering them to take their operations to the next level.
