import { z } from "zod";

export const SampleSizeInputSchema = z.object({
  input1: z
    .number({ error: "Input1 is required" })
    .min(1, "Input1 must be greater than 0"),
  input2: z
    .number({ error: "Input2 is required" })
    .min(1, "Input2, must be greater then '"),
  sampleSize: z
    .number({ error: "SampleSize is required" })
    .max(10000000, "SampleSize must be less than 1 000 000"),
});

export type SampleSizeInput = z.infer<typeof SampleSizeInputSchema>;

export const SampleSizeRequestSchema = z.object({
  page: z.number(),
  pageSize: z.number(),
  data: SampleSizeInputSchema,
});

export type SampleSizeRequest = z.infer<typeof SampleSizeRequestSchema>;

export const SampleSizeItemSchema = z.object({
  number: z.number(),
  result: z.number(),
});

export const SampleSizeResponseSchema = z.object({
  items: z.array(SampleSizeItemSchema),
  page: z.number(),
  pageSize: z.number(),
  totalPages: z.number(),
  totalItems: z.number(),
});

export type SampleSizeItem = z.infer<typeof SampleSizeItemSchema>;
export type SampleSizeResponse = z.infer<typeof SampleSizeResponseSchema>;
