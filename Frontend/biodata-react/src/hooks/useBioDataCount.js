import Axios from "axios";
import { useEffect, useState } from "react";

export const useBioDataCount = init => {
  const [countedValues, setCountedValues] = useState(init);
  const [property, setProperty] = useState(init);

  useEffect(() => {
    let didCancel = false;

    const executeCountQuery = async () => {
      let countResult = await Axios.request({
        url: `?property=${property}`,
        method: "get",
        baseURL: process.env.REACT_APP_BASE_URL,
      });
      var counts = countResult.data.reduce((map, val) => {
        map[val] = (map[val] || 0) + 1;
        return map;
      }, {});
      setCountedValues(counts);
    };

    if (!didCancel && property) {
      executeCountQuery();
    }

    return () => (didCancel = true);
  }, [property]);

  return [countedValues, setProperty];
};
