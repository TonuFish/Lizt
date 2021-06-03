# Very simple script is very simple derp

$startTime = [System.DateTime]::Now
Write-Host 'Start time: ' $startTime

Write-Host 'BENCHMARK: Byte'
dotnet run -p benchmarks/Lizt.Benchmarks/Lizt.Benchmarks.csproj --framework net5.0 -c Release 'FindIndex' 'Array_Byte'
Write-Host 'BENCHMARK: SByte'
dotnet run -p benchmarks/Lizt.Benchmarks/Lizt.Benchmarks.csproj --framework net5.0 -c Release 'FindIndex' 'Array_SByte'
Write-Host 'BENCHMARK: Int16'
dotnet run -p benchmarks/Lizt.Benchmarks/Lizt.Benchmarks.csproj --framework net5.0 -c Release 'FindIndex' 'Array_Int16'
Write-Host 'BENCHMARK: UInt16'
dotnet run -p benchmarks/Lizt.Benchmarks/Lizt.Benchmarks.csproj --framework net5.0 -c Release 'FindIndex' 'Array_UInt16'
Write-Host 'BENCHMARK: Int32'
dotnet run -p benchmarks/Lizt.Benchmarks/Lizt.Benchmarks.csproj --framework net5.0 -c Release 'FindIndex' 'Array_Int32'
Write-Host 'BENCHMARK: UInt32'
dotnet run -p benchmarks/Lizt.Benchmarks/Lizt.Benchmarks.csproj --framework net5.0 -c Release 'FindIndex' 'Array_UInt32'
Write-Host 'BENCHMARK: Int64'
dotnet run -p benchmarks/Lizt.Benchmarks/Lizt.Benchmarks.csproj --framework net5.0 -c Release 'FindIndex' 'Array_Int64'
Write-Host 'BENCHMARK: UInt64'
dotnet run -p benchmarks/Lizt.Benchmarks/Lizt.Benchmarks.csproj --framework net5.0 -c Release 'FindIndex' 'Array_UInt64'
Write-Host 'BENCHMARK: Single'
dotnet run -p benchmarks/Lizt.Benchmarks/Lizt.Benchmarks.csproj --framework net5.0 -c Release 'FindIndex' 'Array_Single'
Write-Host 'BENCHMARK: Double'
dotnet run -p benchmarks/Lizt.Benchmarks/Lizt.Benchmarks.csproj --framework net5.0 -c Release 'FindIndex' 'Array_Double'
Write-Host 'Finished!'

$finishTime = [System.DateTime]::Now
Write-Host 'Start time: ' $startTime
Write-Host 'Finish time: ' $finishTime

$elapsedTime = $finishTime - $startTime
Write-Host 'Elapsed time:'
Write-Host $elapsedTime