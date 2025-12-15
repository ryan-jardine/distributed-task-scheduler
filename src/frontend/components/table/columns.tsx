"use client";
import { ColumnDef } from "@tanstack/react-table";

export type TaskStatus = {
  id: number;
  status: "pending" | "processing" | "completed" | "failed";
  taskType: "Email" | "File Processing";
  startTime: Date;
};

function formatDuration(startTime: Date) {
  const diffMs = Date.now() - startTime.getTime();

  if (diffMs < 0) return "—";

  const seconds = Math.floor(diffMs / 1000);
  const minutes = Math.floor(seconds / 60);
  const hours = Math.floor(minutes / 60);

  if (hours > 0) return `${hours}h ${minutes % 60}m`;
  if (minutes > 0) return `${minutes}m ${seconds % 60}s`;
  return `${seconds}s`;
}

export const columns: ColumnDef<TaskStatus>[] = [
  {
    accessorKey: "taskType",
    header: "Task Type",
  },
  {
    accessorKey: "status",
    header: "Status",
  },
  {
    id: "duration",
    header: "Duration",
    accessorFn: (row) => row.startTime,
    cell: ({ getValue }) => {
      const startTime = getValue<Date>();
      return formatDuration(startTime);
    },
  },
];
