# AdventOfCode

## Setup a new project for a new day

### 1. Create the folder

```bash
mkdir -p src/Year2025/DayXX
```

### 2. Create the console project

```bash
dotnet new console -n DayXX -o src/Year2025/DayXX
```

### 3. Add the project to the solution

```bash
dotnet sln add src/Year2025/DayXX/DayXX.csproj
```

### 4. Add a reference to Common (optional)

```bash
dotnet add src/Year2025/DayXX/DayXX.csproj reference src/Common/Common.csproj
```

### 5. Add your input file

Create:

```
src/Year2025/DayXX/input.txt
```

### 6. Run the day's solution

```bash
dotnet run --project src/Year2025/DayXX
```
