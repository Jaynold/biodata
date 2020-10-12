import Axios from "axios";
import { useEffect, useState } from "react";

export const useBioData = init => {
  const [response, setResponse] = useState(init);
  const [config, setConfig] = useState(init);

  useEffect(() => {
    let didCancel = false;
    const executeFetchQuery = async () => {
      let fetchResult = await Axios.request({
        ...config,
        baseURL: process.env.REACT_APP_BASE_URL,
      });
      setResponse(fetchResult.data);
    };

    if (!didCancel && config) {
      executeFetchQuery();
    }

    return () => (didCancel = true);
  }, [config]);

  return [response, setConfig];
};
