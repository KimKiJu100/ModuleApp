using Modules.Parsers.MetaField;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Modules.Parsers
{
    public class FrameSchemaParser
    {
        private FrameSchema _schema;

        public FrameSchemaParser(FrameSchema schema)
        {
            _schema = schema;
        }

        public TModel Parse<TModel>(byte[] frame) where TModel : new()
        {
            var model = new TModel();
            var type = typeof(TModel);

            foreach (var field in _schema.Fields)
            {
                var prop = type.GetProperty(field.Name);
                if (prop == null) continue;

                var slice = frame.Skip(field.Offset).Take(field.Length).ToArray();
                prop.SetValue(model, slice);
            }

            return model;
        }
    }
}
