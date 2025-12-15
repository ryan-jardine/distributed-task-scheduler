import Header from "@/components/header";
import Overview from "@/components/overview";
import Description from "@/components/table/description";
import TaskTable from "@/components/table/task-table";

export default async function Home() {
  return (
    <>
      <Header />

      <Description />

      <TaskTable />

      <Overview />
    </>
  );
}
