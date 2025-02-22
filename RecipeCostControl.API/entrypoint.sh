#!/bin/bash
set -e

# Run EF Core migrations
dotnet ef database update

# Start the application
exec "$@"