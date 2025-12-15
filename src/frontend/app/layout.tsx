import type { Metadata } from "next";
import "./globals.css";

export const metadata: Metadata = {
  title: "Distributed Task Scheduler Visualizer",
};

export default function RootLayout({
  children,
}: Readonly<{
  children: React.ReactNode;
}>) {
  return (
    <html lang="en">
      <body className={`antialiased min-h-screen bg-zinc-950 text-zinc-50`}>
        <div className="container mx-auto py-10 grid grid-cols-7 gap-4">
          <div className="col-span-2">side</div>
          <div className="col-span-5">{children}</div>
        </div>
      </body>
    </html>
  );
}
