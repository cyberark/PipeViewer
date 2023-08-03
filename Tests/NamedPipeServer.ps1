Write-Host "pipe server"
$count = 0
$pipeName = "Foo"

$pipe = New-Object System.IO.Pipes.NamedPipeServerStream($pipeName, [System.IO.Pipes.PipeDirection]::InOut, 1, [System.IO.Pipes.PipeTransmissionMode]::Message, [System.IO.Pipes.PipeOptions]::None)

try {
    Write-Host "waiting for client"
    $pipe.WaitForConnection()
    Write-Host "got client"

    while ($true) {
        Write-Host "writing message #$count"

        # Read data from the client
        $readBuffer = New-Object byte[] 1024
        $bytesRead = $pipe.Read($readBuffer, 0, $readBuffer.Length)
        $receivedData = [System.Text.Encoding]::ASCII.GetString($readBuffer, 0, $bytesRead)
        Write-Host $receivedData

        # Convert data to uppercase
        $responseData = $receivedData.ToUpper()

        # Write data to the client
        $responseBytes = [System.Text.Encoding]::ASCII.GetBytes($responseData)
        try {
        $pipe.Write($responseBytes, 0, $responseBytes.Length)
        $pipe.Flush()
        } catch [System.Exception] {
           Write-Host "connection was lost"
           $pipe.Dispose()
           $pipe = New-Object System.IO.Pipes.NamedPipeServerStream($pipeName, [System.IO.Pipes.PipeDirection]::InOut, 1, [System.IO.Pipes.PipeTransmissionMode]::Message, [System.IO.Pipes.PipeOptions]::None)
           Write-Host "waiting for client"
           $pipe.WaitForConnection()
           Write-Host "got client 2"
        }

        $count++
        Start-Sleep -Seconds 2
    }
} catch [system.ArgumentNullException], [system.InvalidOperationException], [system.InvalidOperationException], [system.ObjectDisposedException] {
    Write-Host $_.ScriptStackTrace
}
finally {
    $pipe.Dispose()
}