import Axios from "axios";
import { useEffect, useState } from "react";

export const useBioData = init => {
  const [response, setResponse] = useState(init);
  const [config, setConfig] = useState(init);

  useEffect(() => {
    let didCancel = false;
    const executeQuery = async () => {
      let result;
      result = await Axios.request({
        ...config,
        baseURL: process.env.REACT_APP_BASE_URL,
      });
      setResponse(result.data);
    };

    if (!didCancel && config) executeQuery();

    return () => (didCancel = true);
  }, [config]);

  return [response, setConfig];
};
