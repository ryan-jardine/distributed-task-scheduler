import { DataTable } from "./data-table";
import { columns, TaskStatus } from "./columns";

async function getData(): Promise<TaskStatus[]> {
  const now = Date.now();

  return [
    {
      id: 1,
      status: "processing",
      taskType: "Email",
      startTime: new Date(now - 45 * 1000), // 45s ago
    },
    {
      id: 2,
      status: "pending",
      taskType: "File Processing",
      startTime: new Date(now - 2 * 60 * 1000), // 2m ago
    },
    {
      id: 3,
      status: "processing",
      taskType: "Email",
      startTime: new Date(now - 12 * 60 * 1000), // 12m ago
    },
    {
      id: 4,
      status: "completed",
      taskType: "File Processing",
      startTime: new Date(now - 58 * 60 * 1000), // 58m ago
    },
    {
      id: 5,
      status: "failed",
      taskType: "Email",
      startTime: new Date(now - 1.5 * 60 * 60 * 1000), // 1h 30m ago
    },
    {
      id: 6,
      status: "processing",
      taskType: "File Processing",
      startTime: new Date(now - 3 * 60 * 60 * 1000), // 3h ago
    },
  ];
}

const TaskTable = async () => {
  const data = await getData();
  return (
    <div className="col-span-5 max-h-[275px] overflow-y-auto">
      <DataTable columns={columns} data={data} />
    </div>
  );
};

export default TaskTable;
