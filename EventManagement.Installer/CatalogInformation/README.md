# Event Management Backend Installer

## About

The **Event Management Backend Installer** is an essential companion to the [Skyline.DataMiner.Learning.EventManagement](https://www.nuget.org/packages/Skyline.DataMiner.Learning.EventManagement/) NuGet package.

This installer automatically sets up all required DataMiner Object Model (DOM) definitions, enabling you to start managing events immediately. It was created for Skyline Empower demonstrations, and serves as a best-practice example for setting up SDM-based solutions in DataMiner.

> [!NOTE]
> This installer is designed to be idempotent. You can safely run it multiple times without creating duplicate definitions.

## What does it do?

The installer creates and configures:

- **DOM Module Definition**: `exampleventmgmt` module with proper namespace and settings
- **Section Definitions**: Structured schema for event data storage
- **Field Descriptors**: Strongly-typed fields for all event properties (Name, Status, Type, Dates, Languages, etc.)
- **Status System**: Pre-configured workflow states (Scheduled, In Progress, Completed, Canceled)

All DOM structures are automatically aligned with the Event model from the backend NuGet package, ensuring seamless integration.

## Why do you need this?

Before you can use the **Example Event Management Backend** API in your DataMiner scripts, the underlying DOM structure must exist on your DataMiner System.

This installer:

- **Automates Setup**: No manual DOM configuration required
- **Ensures Consistency**: DOM structure matches the API models exactly
- **Saves Time**: Deploy in seconds instead of hours of manual work
- **Prevents Errors**: Eliminates human error in DOM definition creation
- **Enables Updates**: Safely updates DOM structure when the backend evolves

## Prerequisites

- DataMiner version 10.5.9 or higher
- DOM available and accessible on your DataMiner System

## Example after installation

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
newEvent.Status = EventStatus.Processing;
eventApi.Events.Update(newEvent);
```
