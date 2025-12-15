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
    <html lang="en" className="dark">
      <body
        className={`antialiased min-h-screen bg-background text-foreground`}
      >
        <div className="container mx-auto py-10 grid grid-cols-7 gap-4">
          {children}
        </div>
      </body>
    </html>
  );
}
