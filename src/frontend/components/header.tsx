import React from "react";

const Header = () => {
  return (
    <div className="mb-6 col-span-7">
      <h1 className="text-2xl font-semibold tracking-tight">
        Task Processing Dashboard
      </h1>
      <p className="text-sm text-muted-foreground mt-1">
        Real-time visibility into background job execution and system health.
      </p>
    </div>
  );
};

export default Header;
