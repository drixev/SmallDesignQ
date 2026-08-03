import { useState } from "react";
import { Button } from "@/components/ui/button";
import { Input } from "@/components/ui/input";
import { Label } from "@/components/ui/label";
import { useGenerateSampleSize } from "../api/use-generate";
import { useForm } from "react-hook-form";
import { zodResolver } from "@hookform/resolvers/zod";
import {
  type SampleSizeInput,
  SampleSizeInputSchema,
} from "../schemas/sample.schema";
import { Header } from "@/components/shared/Header";

const PAGE_SIZE = 10;

const ResultType: Record<number, string> = {
  0: "Yes",
  1: "No",
  2: "I don't know",
  3: "N/A",
};

export const Dashboard = () => {
  const [page, setPage] = useState(1);
  const [formData, setFormData] = useState<SampleSizeInput | null>(null);

  const {
    formState: { errors },
    register,
    handleSubmit,
  } = useForm({
    resolver: zodResolver(SampleSizeInputSchema),
  });

  const { data: samples, isLoading } = useGenerateSampleSize(
    {
      page,
      pageSize: PAGE_SIZE,
      data: formData as SampleSizeInput,
    },
    { enabled: formData !== null },
  );

  const onGenerate = handleSubmit((values) => {
    setPage(1);
    setFormData(values);
  });

  return (
    <div className="mx-auto max-w-lg space-y-4 p-6">
      <Header />

      <form
        onSubmit={onGenerate}
        className="grid grid-cols-3 gap-3 rounded-lg border border-border p-4"
      >
        <div className="space-y-1.5">
          <Label htmlFor="input1">Input1</Label>
          <Input
            id="input1"
            type="number"
            {...register("input1", { valueAsNumber: true })}
          />
          {errors.input1 && (
            <p className="text-xs text-destructive">{errors.input1.message}</p>
          )}
        </div>

        <div className="space-y-1.5">
          <Label htmlFor="input2">Input2</Label>
          <Input
            id="input2"
            type="number"
            {...register("input2", { valueAsNumber: true })}
          />
          {errors.input2 && (
            <p className="text-xs text-destructive">{errors.input2.message}</p>
          )}
        </div>

        <div className="space-y-1.5">
          <Label htmlFor="sampleSize">Sample size</Label>
          <Input
            id="sampleSize"
            type="number"
            {...register("sampleSize", { valueAsNumber: true })}
          />
          {errors.sampleSize && (
            <p className="text-xs text-destructive">
              {errors.sampleSize.message}
            </p>
          )}
        </div>

        <Button type="submit" className="col-span-3">
          Generate
        </Button>
      </form>

      <div className="overflow-hidden rounded-lg border border-border">
        <table className="w-full text-sm">
          <thead>
            <tr className="border-b border-border bg-muted/50">
              <th className="px-4 py-2 text-left font-medium">Numbers</th>
              <th className="px-4 py-2 text-left font-medium">Results</th>
            </tr>
          </thead>
          <tbody>
            {isLoading && (
              <tr>
                <td colSpan={2}>Loading...</td>
              </tr>
            )}

            {!isLoading && samples?.items.length ? (
              samples?.items.map(({ number, result }) => (
                <tr
                  key={number}
                  className="border-b border-border last:border-0"
                >
                  <td className="px-4 py-2">{number}</td>
                  <td className="px-4 py-2">{ResultType[result]}</td>
                </tr>
              ))
            ) : (
              <tr>
                <td colSpan={2}>
                  <p>There not result. Generate First</p>
                </td>
              </tr>
            )}
          </tbody>
        </table>
      </div>

      <div className="flex items-center justify-between">
        <Button
          variant="outline"
          size="sm"
          disabled={page === 1}
          onClick={() => setPage((p) => p - 1)}
        >
          Previous
        </Button>

        <span className="text-sm text-muted-foreground">
          Page {page} of {samples?.totalPages ?? 0}
        </span>

        <Button
          variant="outline"
          size="sm"
          disabled={page === samples?.totalPages}
          onClick={() => setPage((p) => p + 1)}
        >
          Next
        </Button>
      </div>
    </div>
  );
};
