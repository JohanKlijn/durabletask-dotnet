﻿//  ----------------------------------------------------------------------------------
//  Copyright Microsoft Corporation
//  Licensed under the Apache License, Version 2.0 (the "License");
//  you may not use this file except in compliance with the License.
//  You may obtain a copy of the License at
//  http://www.apache.org/licenses/LICENSE-2.0
//  Unless required by applicable law or agreed to in writing, software
//  distributed under the License is distributed on an "AS IS" BASIS,
//  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//  See the License for the specific language governing permissions and
//  limitations under the License.
//  ----------------------------------------------------------------------------------

using System;
using Microsoft.Extensions.Logging;

namespace DurableTask
{
    // NOTE: Trying to make logs consistent with https://github.com/Azure/durabletask/blob/main/src/DurableTask.Core/Logging/LogEvents.cs.
    static partial class Logs
    {
        [LoggerMessage(EventId = 1, Level = LogLevel.Information, Message = "Task hub worker is connecting to {address}.")]
        public static partial void StartingTaskHubWorker(this ILogger logger, string address);

        [LoggerMessage(EventId = 2, Level = LogLevel.Information, Message = "Task hub worker has disconnected from {address}.")]
        public static partial void TaskHubWorkerDisconnected(this ILogger logger, string address);

        [LoggerMessage(EventId = 3, Level = LogLevel.Information, Message = "The sidecar at address {address} is unavailable. Will continue retrying.")]
        public static partial void SidecarUnavailable(this ILogger logger, string address);

        [LoggerMessage(EventId = 10, Level = LogLevel.Debug, Message = "{instanceId}: Received request for '{name}' orchestrator.")]
        public static partial void ReceivedOrchestratorRequest(this ILogger logger, string name, string instanceId);

        [LoggerMessage(EventId = 11, Level = LogLevel.Debug, Message = "{instanceId}: Sending {count} actions for '{name}' orchestrator.")]
        public static partial void SendingOrchestratorResponse(this ILogger logger, string name, string instanceId, int count);

        [LoggerMessage(EventId = 12, Level = LogLevel.Warning, Message = "{instanceId}: '{name}' orchestrator failed with an unhandled exception: {details}.")]
        public static partial void OrchestratorFailed(this ILogger logger, string name, string instanceId, string details);

        [LoggerMessage(EventId = 13, Level = LogLevel.Debug, Message = "{instanceId}: Received request for '{name}#{taskId}' activity with {sizeInBytes} bytes of input data.")]
        public static partial void ReceivedActivityRequest(this ILogger logger, string name, int taskId, string instanceId, int sizeInBytes);

        [LoggerMessage(EventId = 14, Level = LogLevel.Debug, Message = "{instanceId}: Sending response for '{name}#{taskId}' activity with {sizeInBytes} bytes of output data.")]
        public static partial void SendingActivityResponse(this ILogger logger, string name, int taskId, string instanceId, int sizeInBytes);

        [LoggerMessage(EventId = 20, Level = LogLevel.Error, Message = "Unexpected error in handling of instance ID '{instanceId}'. Details: {details}")]
        public static partial void UnexpectedError(this ILogger logger, string instanceId, string details);

        [LoggerMessage(EventId = 21, Level = LogLevel.Warning, Message = "Received and dropped an unknown '{type}' work-item from the sidecar.")]
        public static partial void UnexpectedWorkItemType(this ILogger logger, string type);

        [LoggerMessage(EventId = 22, Level = LogLevel.Warning, Message = "Connection to the worker failed. Attempting to reconnect.")]
        public static partial void ConnectionFailed(this ILogger logger);

        [LoggerMessage(EventId = 23, Level = LogLevel.Warning, Message = "The worker is busy servicing other clients. Waiting for the worker to become available for a new connection.")]
        public static partial void WorkerBusy(this ILogger logger);

        // Management APIs
        [LoggerMessage(EventId = 40, Level = LogLevel.Information, Message = "Scheduling new {name} orchestration with instance ID '{instanceId}' and {sizeInBytes} bytes of input data.")]
        public static partial void SchedulingOrchestration(this ILogger logger, string instanceId, string name, int sizeInBytes, DateTimeOffset startTime);

        // NOTE: fetchInputsAndOutputs seems like something that could be left out of the text message and just included in the structured logs
        [LoggerMessage(EventId = 42, Level = LogLevel.Information, Message = "Waiting for instance '{instanceId}' to start.")]
        public static partial void WaitingForInstanceStart(this ILogger logger, string instanceId, bool fetchInputsAndOutputs);

        // NOTE: fetchInputsAndOutputs seems like something that could be left out of the text message and just included in the structured logs
        [LoggerMessage(EventId = 43, Level = LogLevel.Information, Message = "Waiting for instance '{instanceId}' to complete, fail, or terminate.")]
        public static partial void WaitingForInstanceCompletion(this ILogger logger, string instanceId, bool fetchInputsAndOutputs);

        [LoggerMessage(EventId = 44, Level = LogLevel.Information, Message = "Terminating instance '{instanceId}'.")]
        public static partial void TerminatingInstance(this ILogger logger, string instanceId);
    }
}