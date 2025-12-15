import React from "react";

const Description = () => {
  return (
    <div className="col-span-2 text-sm text-muted-foreground space-y-3">
      <h2 className="text-base font-semibold ">Distributed Task Monitor</h2>

      <p>
        This view provides real-time visibility into background tasks being
        processed across the system. Each row represents an individual task,
        including its type, current status, and how long it has been running.
      </p>

      <p>
        The duration column updates live based on each task’s start time, making
        it easy to identify long-running or stalled jobs without needing to
        refresh the page.
      </p>

      <p>
        This table is designed to mirror how a production task queue or job
        scheduler might be monitored in a distributed environment.
      </p>
    </div>
  );
};

export default Description;
