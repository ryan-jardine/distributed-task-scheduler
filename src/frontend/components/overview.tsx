import React from "react";

const Overview = () => {
  return (
    <div className="mt-6 space-y-3 text-sm text-muted-foreground col-span-7">
      <h3 className="text-sm font-semibold text-foreground">Project Stack</h3>

      <p>
        The backend is built with{" "}
        <span className="font-medium text-foreground">ASP.NET 10</span> and
        <span className="font-medium text-foreground"> C#</span>, exposing an
        API that publishes tasks to{" "}
        <span className="font-medium text-foreground">RabbitMQ</span>. Dedicated
        worker services consume these messages asynchronously and execute
        background jobs independently of the API layer.
      </p>

      <p>
        The frontend is implemented using{" "}
        <span className="font-medium text-foreground">Next.js 16</span> with
        <span className="font-medium text-foreground"> React 19</span>, styled
        using
        <span className="font-medium text-foreground"> Tailwind CSS</span> and
        <span className="font-medium text-foreground"> shadcn/ui</span>. It
        provides a real-time view into task state and execution duration without
        requiring page refreshes.
      </p>

      <p>
        All services are containerized using{" "}
        <span className="font-medium text-foreground">Docker</span>, enabling
        consistent local development and production-ready deployment across the
        API, worker processes, message broker, and frontend.
      </p>
    </div>
  );
};

export default Overview;
