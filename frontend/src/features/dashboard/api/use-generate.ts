import { httpClient } from "@/lib/http-client";
import {
  type SampleSizeRequest,
  SampleSizeResponseSchema,
} from "../schemas/sample.schema";
import { useQuery } from "@tanstack/react-query";

const generateSampleSize = async (request: SampleSizeRequest) => {
  const res = await httpClient(
    `/api/generate?page=${request.page}&pageSize=${request.pageSize}`,
    {
      method: "POST",
      body: JSON.stringify(request.data),
    },
  );

  console.log(res);
  return SampleSizeResponseSchema.parse(res);
};

export const useGenerateSampleSize = (
  request: SampleSizeRequest,
  options?: { enabled?: boolean },
) => {
  return useQuery({
    queryKey: ["samples", request.page, request.pageSize, request.data],
    queryFn: () => generateSampleSize(request),
    enabled: options?.enabled ?? true,
  });
};
