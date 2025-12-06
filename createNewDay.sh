#!/bin/bash

# Usage: ./new_day.sh <year> <day_number>
# Example: ./new_day.sh 2025 4
# Day number can be 1-25; it will be zero-padded to two digits

if [ -z "$1" ] || [ -z "$2" ]; then
    echo "Usage: $0 <year> <day_number>"
    exit 1
fi

YEAR="$1"
DAY="$2"
DAY_PADDED=$(printf "%02d" "$DAY")
PROJECT_DIR="src/Year$YEAR/Day$DAY_PADDED"

# 1. Create folder
mkdir -p "$PROJECT_DIR"

# 2. Create console project
dotnet new console -n "Day$DAY_PADDED" -o "$PROJECT_DIR"

# 3. Add project to solution
dotnet sln add "$PROJECT_DIR/Day$DAY_PADDED.csproj"

# 4. Add reference to Common (optional, only if Common exists)
if [ -f "src/Common/Common.csproj" ]; then
    dotnet add "$PROJECT_DIR/Day$DAY_PADDED.csproj" reference src/Common/Common.csproj
fi
